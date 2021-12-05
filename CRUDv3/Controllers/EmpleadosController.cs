using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDv3.Models;
using CRUDv3.Models.ViewModels;

namespace CRUDv3.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            List<ListEmpleadosViewModel> list;
            using (CrudEntities db = new CrudEntities())
            {
                list = (from d in db.empleados
                        select new ListEmpleadosViewModel
                        {
                            Id = d.id,
                            Nombres = d.nombres,
                            Apellidos = d.apellidos,
                            Fecha_Nacimiento = d.fecha_nacimiento,
                            Sueldo = d.sueldo,
                            Departamento = d.departamento

                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Nuevo(EmpleadosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oEmpleados = new empleados();
                        oEmpleados.nombres = model.Nombres;
                        oEmpleados.apellidos = model.Apellidos;
                        oEmpleados.fecha_nacimiento = model.Fecha_Nacimiento;
                        oEmpleados.sueldo = model.Sueldo;
                        oEmpleados.departamento= model.Departamento;

                        db.empleados.Add(oEmpleados);
                        db.SaveChanges();
                    }

                    return Redirect("~/Empleados/");
                }
                return View(model);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            EmpleadosViewModel model = new EmpleadosViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oEmpleados = db.empleados.Find(Id);
                model.Nombres = oEmpleados.nombres;
                model.Apellidos = oEmpleados.apellidos;
                model.Fecha_Nacimiento = oEmpleados.fecha_nacimiento;
                model.Sueldo = oEmpleados.sueldo;
                model.Departamento = oEmpleados.departamento;
                model.Id = oEmpleados.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EmpleadosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oEmpleados = db.empleados.Find(model.Id);
                        oEmpleados.nombres = model.Nombres;
                        oEmpleados.apellidos = model.Apellidos;
                        oEmpleados.fecha_nacimiento = model.Fecha_Nacimiento;
                        oEmpleados.sueldo = model.Sueldo;
                        oEmpleados.departamento = model.Departamento;

                        db.Entry(oEmpleados).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Empleados/");
                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntities db = new CrudEntities())
            {
                var oEmpleados = db.empleados.Find(Id);
                db.empleados.Remove(oEmpleados);
                db.SaveChanges();
            }
            return Redirect("~/Empleados/");
        }


    }
}