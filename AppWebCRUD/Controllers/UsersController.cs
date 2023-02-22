using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppWebCRUD.Data.models;
using AppWebCRUD.Data.repositories;
using X.PagedList;


namespace AppWebCRUD.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userService;
         
        public UsersController(IUserRepository userService)
        {
            _userService= userService;
            
        }
        

        // GET: Users
        public async Task<IActionResult> Index(int? pageSize,int? page)
        {
            var users= await _userService.GetAll();
            pageSize = (pageSize ?? 10);
            page= (page ?? 1);
            // ViewBag.pageZise = users.ToList().ToPagedList(pageNumber, 1);
            ViewBag.PageZise = pageSize.Value;            
            ViewBag.Page = page.Value;
            //return View(await _userService.GetAll());
            return View(users.ToList().ToPagedList(page.Value, pageSize.Value));
        }

        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user =await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            //User user = tmpUser
            user.Activo = !user.Activo;
            var res= await _userService.Update(user);             
            return res;
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidId,Name,LastName,Activo,FechaRegistro")] User user)
        {
            if (ModelState.IsValid)
            {
                user.GuidId = Guid.NewGuid();
                var userNew=_userService.Insert(user);                
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidId,Name,LastName,Activo,FechaRegistro")] User user)
        {
            if (id != user.GuidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await  _userService.Update(user);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.GuidId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        
        public async Task<Boolean> DeleteConfirmed(Guid id)
        {

            var user = await _userService.GetById(id);
            if (user != null)
            {
                await _userService.Delete(id);                
            }
            return true; 
        }

        private bool UserExists(Guid id)
        {
            var user = _userService.GetById(id);
            return (user!=null)?true: false;
        }
    }
}
