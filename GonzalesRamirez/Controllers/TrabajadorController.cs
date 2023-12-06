using Microsoft.AspNetCore.Mvc;

using GonzalesRamirez.Datos;
using GonzalesRamirez.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GonzalesRamirez.Controllers
{
    public class TrabajadorController : Controller
    {
        TrabajadorDatos _TrabajadorDatos = new TrabajadorDatos();
        public IActionResult Listar()
        {
            var oLista = _TrabajadorDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            var provinciasDatos = new ProvinciaDatos();
            var provincias = provinciasDatos.Listar();

            var departamentosDatos = new DepartamentoDatos();
            var departamentos = departamentosDatos.Listar();

            var distritoDatos = new DistritoDatos();
            var distritos = distritoDatos.Listar();

            ViewBag.Departamentos = new SelectList(departamentos, "IdDepartamento", "NombreDepartamento");
            ViewBag.Provincias = new SelectList(provincias, "IdProvincia", "NombreProvincia");
            ViewBag.Distritos = new SelectList(distritos, "IdDistrito", "NombreDistrito");

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Trabajador oTrabajador)
        {

           // if (!ModelState.IsValid)
            //    return View();


            var respuesta = _TrabajadorDatos.Guardar(oTrabajador);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdTrabajador)
        {
            var oTrabajador = _TrabajadorDatos.Obtener(IdTrabajador);
            return View(oTrabajador);
        }


        [HttpPost]
        public IActionResult Editar(Trabajador oTrabajador)
        {
            //if (!ModelState.IsValid)
            //    return View();


            var respuesta = _TrabajadorDatos.Editar(oTrabajador);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdTrabajador)
        {
            var oTrabajador = _TrabajadorDatos.Obtener(IdTrabajador);
            return View(oTrabajador);
        }

        [HttpPost]
        public IActionResult Eliminar(Trabajador oTrabajador)
        {

            var respuesta = _TrabajadorDatos.Eliminar(oTrabajador.IdTrabajador);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
