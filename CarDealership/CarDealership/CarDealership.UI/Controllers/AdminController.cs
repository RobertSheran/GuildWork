using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.TabelModels;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {

        private RepositoryManager carsRepository = RepositoryManagerFactory.Create();



        // GET: Admin
        public ActionResult Cars()
        {
            List<Cars> cars = carsRepository.GetAllCars().Carss;

            List<CarViewModel> carViews = new List<CarViewModel>();
            foreach (var car in cars)
            {
                if (car.Sold)
                {
                    carViews.Add(new CarViewModel()
                    {
                        Photo = "Sold.jpg",
                        CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                        Price = car.SalesPrice,
                        Year = car.CarYear,
                        CarId = car.CarId

                    });
                }
                else
                {
                    carViews.Add(new CarViewModel()
                    {
                        Photo = car.Photo,
                        CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                        Price = car.SalesPrice,
                        Year = car.CarYear,
                        CarId = car.CarId

                    });
                }


            }
            return View(carViews);
        }
        public ActionResult NewInventory()
        {
            var cars = carsRepository.GetAllNew().Carss.GroupBy(c=>c.CarModelId);
            List<InventoryItemView> list = new List<InventoryItemView>();
            foreach (var group in cars)
            {
                var onYear = group.GroupBy(c => c.CarYear);
                foreach (var group2 in onYear)
                {
                    var count = 0;
                    var stockValue = 0;
                    foreach (var car in group2)
                    {
                        count++;
                    }
                    foreach (var car in group2)
                    {
                        stockValue += car.SalesPrice;
                    }
                    InventoryItemView itemView = new InventoryItemView()
                    {
                        CarModel = carsRepository.GetCarModel(group.Key).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(group.Key).CarModel.MakeId).Make.MakeName,
                        Count = count,
                        StockValue = stockValue,
                        Year = group2.Key
                    };
                    list.Add(itemView);
                }
                
            }
            return View(list);
        }
        public ActionResult UsedInventory()
        {
            var cars = carsRepository.GetAllUsed().Carss.GroupBy(c => c.CarModelId);
            List<InventoryItemView> list = new List<InventoryItemView>();
            foreach (var group in cars)
            {
                var onYear = group.GroupBy(c => c.CarYear);
                foreach (var group2 in onYear)
                {
                    var count = 0;
                    var stockValue = 0;
                    foreach (var car in group2)
                    {
                        count++;
                    }
                    foreach (var car in group2)
                    {
                        stockValue += car.SalesPrice;
                    }
                    InventoryItemView itemView = new InventoryItemView()
                    {
                        CarModel = carsRepository.GetCarModel(group.Key).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(group.Key).CarModel.MakeId).Make.MakeName,
                        Count = count,
                        StockValue = stockValue,
                        Year = group2.Key
                    };
                    list.Add(itemView);
                }

            }
            return View(list);
        }





        public ActionResult Create()
        {
            return View(new CreateCarViewModel()
            {
                BodyStyles = carsRepository.GetAllBodyStyle().BodyStyles.Select(m => new SelectListItem
                {
                    Text = m.BodyStyleName,
                    Value = m.BodyStyleId.ToString()
                }),
                Colors = carsRepository.GetAllColor().Colors.Select(c => new SelectListItem
                {
                    Text = c.ColorName,
                    Value = c.ColorId.ToString()
                }),
                Interiors = carsRepository.GetAllInteriorColors().InteriorColorss.Select(m => new SelectListItem
                {
                    Text = m.InteriorColorName,
                    Value = m.InteriorColorId.ToString()
                }),
                CarId = carsRepository.GetAllCars().Carss.Max(c => c.CarId) + 1,
                Makes = carsRepository.GetAllMake().Makes.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                }),
                Models = carsRepository.GetAllCarModel().CarModels.Select(m => new SelectListItem
                {
                    Text = m.CarModelName,
                    Value = m.CarModelId.ToString()
                }),
                Transmissions = carsRepository.GetAllTransmission().Transmissions.Select(m => new SelectListItem
                {
                    Text = m.TransmissionName,
                    Value = m.TransmissionId.ToString()
                }),
                Types = carsRepository.GetAllCarType().CarTypes.Select(m => new SelectListItem
                {
                    Text = m.CarTypeName,
                    Value = m.CarTypeId.ToString()
                })
            });
        }

        [HttpPost]
        public ActionResult Create(CreateCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photo != null && model.Photo.ContentLength > 0)
                {
                    var savepath = Server.MapPath("~/Images");

                    string fileName = Path.GetFileNameWithoutExtension(model.Photo.FileName);
                    string extension = Path.GetExtension(model.Photo.FileName);

                    var filePath = Path.Combine(savepath, fileName + extension);

                    int counter = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                        counter++;
                    }

                    model.Photo.SaveAs(filePath);
                    model.GottenPicture = Path.GetFileName(filePath);
                }

                carsRepository.AddCars(new Cars()
                {
                    BodyStyleId = model.BodyStyleId,
                    CarTypeId = model.TypeId,
                    CarModelId = model.ModelId,
                    CarYear = model.Year,
                    ColorId = model.ColorId,
                    Discription = model.Discription,
                    InteriorColorId = model.InteriorId,
                    TransmissionId = model.TransmissionId,
                    Mileage = model.Mileage,
                    MSRP = model.MSRP,
                    SalesPrice = model.Price,
                    Sold = false,
                    Special = false,
                    Vin = model.Vin,
                    Photo = model.GottenPicture
                });


                return RedirectToAction("Cars");
            }
            else
            {
                return View(new CreateCarViewModel()
                {
                    BodyStyles = carsRepository.GetAllBodyStyle().BodyStyles.Select(m => new SelectListItem
                    {
                        Text = m.BodyStyleName,
                        Value = m.BodyStyleId.ToString()
                    }),
                    Colors = carsRepository.GetAllColor().Colors.Select(c => new SelectListItem
                    {
                        Text = c.ColorName,
                        Value = c.ColorId.ToString()
                    }),
                    Interiors = carsRepository.GetAllInteriorColors().InteriorColorss.Select(m => new SelectListItem
                    {
                        Text = m.InteriorColorName,
                        Value = m.InteriorColorId.ToString()
                    }),
                    CarId = carsRepository.GetAllCars().Carss.Max(c => c.CarId) + 1,
                    Makes = carsRepository.GetAllMake().Makes.Select(m => new SelectListItem
                    {
                        Text = m.MakeName,
                        Value = m.MakeId.ToString()
                    }),
                    Models = carsRepository.GetAllCarModel().CarModels.Select(m => new SelectListItem
                    {
                        Text = m.CarModelName,
                        Value = m.CarModelId.ToString()
                    }),
                    Transmissions = carsRepository.GetAllTransmission().Transmissions.Select(m => new SelectListItem
                    {
                        Text = m.TransmissionName,
                        Value = m.TransmissionId.ToString()
                    }),
                    Types = carsRepository.GetAllCarType().CarTypes.Select(m => new SelectListItem
                    {
                        Text = m.CarTypeName,
                        Value = m.CarTypeId.ToString()
                    })
                });
            }
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            carsRepository.RemoveCars(id);
            return RedirectToAction("Cars");
        }

        [HttpGet]
        public ActionResult DeleteModel(int id)
        {
            carsRepository.RemoveCarModel(id);

            return RedirectToAction("Model");

        }

        [HttpGet]
        public ActionResult DeleteMake(int id)
        {
            carsRepository.RemoveMake(id);

            return RedirectToAction("Make");

        }

        [HttpGet]
        public ActionResult Model()
        {
            List<CarModelView> carss= new List<CarModelView>();
            foreach(var item in carsRepository.GetAllCarModel().CarModels)
            {
                carss.Add(new CarModelView()
                {
                    CarModelId = item.CarModelId,
                    CarModelName = item.CarModelName,
                    MakeId = item.MakeId                
                });
            }
            return View(carss);
        }
        [HttpGet]
        public ActionResult Make()
        {
            List<CarMakeView> carss = new List<CarMakeView>();
            foreach (var item in carsRepository.GetAllMake().Makes)
            {
                carss.Add(new CarMakeView()
                {
                    MakeId = item.MakeId,
                    MakeName = item.MakeName
                });
            }
            return View(carss);
        }

        [HttpGet]
        public ActionResult CreateMake()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMake(CarMakeView modelView)
        {
            carsRepository.AddMake(new Make()
            {
                MakeName = modelView.MakeName,
                MakeId = modelView.MakeId
            });
            return RedirectToAction("Make");
        }

        [HttpGet]
        public ActionResult CreateCarModel()
        {
            CarModelView modelView = new CarModelView()
            {
                Makes = carsRepository.GetAllMake().Makes.Select(c => new SelectListItem()
                {
                    Text = c.MakeName,
                    Value = c.MakeId.ToString()
                })
            };
            return View(modelView);
        }
        [HttpPost]
        public ActionResult CreateCarModel(CarModelView modelView)
        {
            carsRepository.AddCarModel(new CarModel()
            {
                CarModelName = modelView.CarModelName,
                MakeId = modelView.MakeId
            });
            return RedirectToAction("Model");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cars cars= carsRepository.GetCars(id).Cars;
            EditCarViewModel viewModel = new EditCarViewModel()
            {
                BodyStyles = carsRepository.GetAllBodyStyle().BodyStyles.Select(m => new SelectListItem
                {
                    Text = m.BodyStyleName,
                    Value = m.BodyStyleId.ToString()
                }),
                Colors = carsRepository.GetAllColor().Colors.Select(c => new SelectListItem
                {
                    Text = c.ColorName,
                    Value = c.ColorId.ToString()
                }),
                Interiors = carsRepository.GetAllInteriorColors().InteriorColorss.Select(m => new SelectListItem
                {
                    Text = m.InteriorColorName,
                    Value = m.InteriorColorId.ToString()
                }),
                CarId = id,
                Makes = carsRepository.GetAllMake().Makes.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                }),
                Models = carsRepository.GetAllCarModel().CarModels.Select(m => new SelectListItem
                {
                    Text = m.CarModelName,
                    Value = m.CarModelId.ToString()
                }),
                Transmissions = carsRepository.GetAllTransmission().Transmissions.Select(m => new SelectListItem
                {
                    Text = m.TransmissionName,
                    Value = m.TransmissionId.ToString()
                }),
                Types = carsRepository.GetAllCarType().CarTypes.Select(m => new SelectListItem
                {
                    Text = m.CarTypeName,
                    Value = m.CarTypeId.ToString()
                }),
                Sold = false,
                Special = false,
                Price = cars.SalesPrice,
                Mileage = cars.Mileage,
                MSRP =cars.MSRP,
                Vin = cars.Vin,
                Year = cars.CarYear,
                Discription = cars.Discription
                           
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photo != null && model.Photo.ContentLength > 0)
                {
                    var savepath = Server.MapPath("~/Images");

                    string fileName = Path.GetFileNameWithoutExtension(model.Photo.FileName);
                    string extension = Path.GetExtension(model.Photo.FileName);

                    var filePath = Path.Combine(savepath, fileName + extension);

                    int counter = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                        counter++;
                    }

                    model.Photo.SaveAs(filePath);
                    model.GottenPicture = Path.GetFileName(filePath);
                }
                else
                {
                    model.GottenPicture = carsRepository.GetCars(model.CarId).Cars.Photo;
                }
                carsRepository.EditCars(new Cars()
                {
                    CarId = model.CarId,
                    BodyStyleId = model.BodyStyleId,
                    CarModelId = model.ModelId,
                    CarTypeId = model.TypeId,
                    CarYear = model.Year,
                    ColorId = model.ColorId,
                    Discription = model.Discription,
                    InteriorColorId = model.InteriorId,
                    Mileage = model.Mileage,
                    Vin = model.Vin,
                    MSRP = model.MSRP,
                    SalesPrice = model.Price,
                    Special = model.Special,
                    TransmissionId = model.TransmissionId,
                    Photo = model.GottenPicture
                });

                return RedirectToAction("Cars");
            }
            else
            {
                Cars cars = carsRepository.GetCars(model.CarId).Cars;
                EditCarViewModel viewModel = new EditCarViewModel()
                {
                    BodyStyles = carsRepository.GetAllBodyStyle().BodyStyles.Select(m => new SelectListItem
                    {
                        Text = m.BodyStyleName,
                        Value = m.BodyStyleId.ToString()
                    }),
                    Colors = carsRepository.GetAllColor().Colors.Select(c => new SelectListItem
                    {
                        Text = c.ColorName,
                        Value = c.ColorId.ToString()
                    }),
                    Interiors = carsRepository.GetAllInteriorColors().InteriorColorss.Select(m => new SelectListItem
                    {
                        Text = m.InteriorColorName,
                        Value = m.InteriorColorId.ToString()
                    }),
                    CarId = model.CarId,
                    Makes = carsRepository.GetAllMake().Makes.Select(m => new SelectListItem
                    {
                        Text = m.MakeName,
                        Value = m.MakeId.ToString()
                    }),
                    Models = carsRepository.GetAllCarModel().CarModels.Select(m => new SelectListItem
                    {
                        Text = m.CarModelName,
                        Value = m.CarModelId.ToString()
                    }),
                    Transmissions = carsRepository.GetAllTransmission().Transmissions.Select(m => new SelectListItem
                    {
                        Text = m.TransmissionName,
                        Value = m.TransmissionId.ToString()
                    }),
                    Types = carsRepository.GetAllCarType().CarTypes.Select(m => new SelectListItem
                    {
                        Text = m.CarTypeName,
                        Value = m.CarTypeId.ToString()
                    }),
                    Sold = false,
                    Special = false,
                    Price = cars.SalesPrice,
                    Mileage = cars.Mileage,
                    MSRP = cars.MSRP,
                    Vin = cars.Vin,
                    Year = cars.CarYear,
                    Discription = cars.Discription

                };
                return View(viewModel);
            }
            
        }

        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult People()
        {
            var context = new ApplicationDbContext();
            //This is our role
            var blogger = (from r in context.Roles where r.Name.Contains("Seller") select r).FirstOrDefault();
            //This is the list of users in the role
            var bloggers = context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(blogger.Id));

            var sellerVM = bloggers.Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Role = "Seller"
            }).ToList();

            var admin = (from r in context.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            var admins = context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(admin.Id));

            var adminVM = admins.Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Role = "Admin"
            }).ToList();

            var model = new GroupedViewModel { Sellers = sellerVM, Admins = adminVM };

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles;
            var model = new RegisterViewModel();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    var role = roleManager.FindById(model.Role);
                    UserManager.AddToRole(user.Id, role.Name);
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    context.SaveChanges();

                    return RedirectToAction("People", "Admin");
                }
                AddErrors(result);
            }

            var roles = context.Roles;
            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles;
            var editedUser = UserManager.FindById(id);
            var model = new RegisterViewModel();


            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            model.Id = editedUser.Id;
            model.Email = editedUser.Email;


            foreach (var role in editedUser.Roles)
            {
                model.Role = role.RoleId;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles;
            var user = UserManager.FindById(model.Id);


            if (!string.IsNullOrEmpty(model.EditedPassword))
            {
                user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.EditedPassword);
            }

            user.Email = model.Email;

            var oldRole = user.Roles.SingleOrDefault().RoleId;

            if (!user.Roles.Any(r => r.RoleId == model.Role))
            {

                var dbuser = context.Users.SingleOrDefault(u => u.Id == model.Id);
                dbuser.Roles.Clear();

                context.SaveChanges();

                var role = roles.Where(r => r.Id == model.Role).Select(r => r.Name).SingleOrDefault();

                UserManager.RemoveFromRole(user.Id, oldRole);
                UserManager.AddToRole(user.Id, role);
            }

            UserManager.Update(user);

            return RedirectToAction("People", "Admin");
        }
    }
}