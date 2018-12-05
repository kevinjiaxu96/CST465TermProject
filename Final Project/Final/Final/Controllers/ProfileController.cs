using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Final.Models;
using Final.Models.ProfilViewModels;
using Final.Objects;
using Final.Repositories;

namespace Final.Controllers
{
    [Authorize]
    [Route("/[action]")]
    public class ProfileController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly IFriendRepository _friendRepo;
        private readonly IUserRepository _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(IPostRepository postRepo, IFriendRepository friendRepo, IUserRepository userRepo,UserManager<ApplicationUser> userManager)
        {
            _postRepo = postRepo;
            _friendRepo = friendRepo;
            _userManager = userManager;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            Posts curPosts = new Posts()
            {
                PostList = _postRepo.getPosts(currentUser.Id)
            };
            return View(curPosts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Posts p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            _postRepo.addPost(currentUser.Id, p.Content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Friends()
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            Friends curFriends = new Friends()
            {
                FriendList = _friendRepo.getFriends(currentUser.Id)
            };
            return View(curFriends);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Friends(Friends f)
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                f.FriendList = _friendRepo.getFriends(currentUser.Id);
                return View(f);
            }
            Friends foundFriend = new Friends();
            ApplicationUser searchUser = await _userManager.FindByEmailAsync(f.Email);
            foundFriend.FriendList = _friendRepo.getFriends(currentUser.Id);
            if (searchUser != null)
            {
                ViewBag.found = "true";
                foundFriend.Id = searchUser.Id;
                foundFriend.Email = searchUser.Email;
                foundFriend.Name = searchUser.Name;
            }
            else
            {
                ViewBag.found = "false";
                foundFriend.Email = f.Email;
            }
            return View(foundFriend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFriend(Friends f)
        {
            if (!ModelState.IsValid)
            {
                return View("Friends", f);
            }
            if (User.Identity.Name != f.Email)
            {
                ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
                _friendRepo.addFriend(currentUser.Id, f.Id);
            }
            return RedirectToAction("Friends");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFriend(Friends f)
        {
            if (!ModelState.IsValid)
            {
                return View("Friends", f);
            }
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            ApplicationUser searchUser = await _userManager.FindByEmailAsync(f.Email);
            _friendRepo.removeFriend(currentUser.Id, searchUser.Id);
            return RedirectToAction("Friends");
        }

        [HttpGet]
        public async Task<IActionResult> FriendPosts()
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            List<Friend> myFriends = _friendRepo.getFriends(currentUser.Id);
            Posts allPosts = new Posts();
            allPosts.PostList = new List<Post>();
            for(int i = 0; i < myFriends.Count; ++i)
            {
                List<Post> fPorts = _postRepo.getPosts(myFriends[i].Id);
                for(int j = 0; j < fPorts.Count; ++j)
                {
                    allPosts.PostList.Add(fPorts[j]);
                }
            }
            allPosts.PostList.Sort((p1, p2) =>
            {
                DateTime d1 = DateTime.Parse(p1.date);
                DateTime d2 = DateTime.Parse(p2.date);
                return d1.CompareTo(d2);
            });
            return View(allPosts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePost(Posts post)
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            _postRepo.removePost(currentUser.Id, post.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Restrict()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Restrict(RestrictUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            ApplicationUser foundUser = await _userManager.FindByEmailAsync(user.Email);
            if (foundUser != null)
            {
                bool ifAnAdmin = await _userManager.IsInRoleAsync(foundUser, "Admin");
                if (!ifAnAdmin)
                {
                    _userRepo.restrict(foundUser.Id, true);
                    ViewBag.restrict = "done";
                }
                else
                {
                    ViewBag.restrict = "admin";
                }

            }
            else
            {
                ViewBag.restrict = "not found";
            }
            return View(user);
        }
    }
}