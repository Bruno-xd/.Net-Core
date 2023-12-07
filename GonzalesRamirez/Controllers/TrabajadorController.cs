using Microsoft.AspNetCore.Mvc;

using GonzalesRamirez.Datos;
using GonzalesRamirez.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GonzalesRamirez.Controllers
{
    public class TrabajadorController : Controller
    {
        TrabajadorDatos _TrabajadorDatos = new TrabajadorDatos();
        DepartamentoDatos _DepartamentoDatos = new DepartamentoDatos();
        ProvinciaDatos _ProvinciaDatos = new ProvinciaDatos();
        DistritoDatos _DistritoDatos = new DistritoDatos();
        public IActionResult Listar()
        {
            var oLista = _TrabajadorDatos.Listar();

            var departamentos = _DepartamentoDatos.Listar();
            var provincias = _ProvinciaDatos.Listar();
            var distritos = _DistritoDatos.Listar();

            ViewBag.Departamentos = new SelectList(departamentos, "IdDepartamento", "NombreDepartamento");

            // Crear SelectList vacía para provincias y distritos
            ViewBag.Provincias = new SelectList(new List<Provincia>(), "IdProvincia", "NombreProvincia");
            ViewBag.Distritos = new SelectList(new List<Distrito>(), "IdDistrito", "NombreDistrito");

            return View(oLista);
        }

        [ActionName("ListarConFiltroSexo")]
        public IActionResult Listar(string filtroSexo)
        {
            var trabajadores = _TrabajadorDatos.Listar();

            if (!string.IsNullOrEmpty(filtroSexo))
            {
                trabajadores = trabajadores.Where(t => t.Sexo == filtroSexo).ToList();
            }

            return View("Listar", trabajadores);
        }

        [HttpPost]
        public IActionResult ObtenerProvincias(int idDepartamento)
        {
            // Obtener la lista de provincias filtrada por el idDepartamento
            var provincias = _ProvinciaDatos.ListarPorDepartamento(idDepartamento);

            // Devolver las provincias en formato JSON
            return Json(provincias);
        }

        [HttpPost]
        public IActionResult ObtenerDistritos(int idProvincia)
        {
            // Obtener la lista de distritos filtrada por el idProvincia
            var distritos = _DistritoDatos.ListarPorProvincia(idProvincia);

            // Devolver los distritos en formato JSON
            return Json(distritos);
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

            var respuesta = _TrabajadorDatos.Guardar(oTrabajador);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdTrabajador)
        {
            var oTrabajador = _TrabajadorDatos.Obtener(IdTrabajador);

            var departamentosDatos = new DepartamentoDatos();
            var provinciasDatos = new ProvinciaDatos();
            var distritosDatos = new DistritoDatos();
            var departamentos = departamentosDatos.Listar();
            var provincias = provinciasDatos.Listar();
            var distritos = distritosDatos.Listar();

            var selectedDepartamento = oTrabajador.IdDepartamento;
            var selectedProvincia = oTrabajador.IdProvincia;
            var selectedDistrito = oTrabajador.IdDistrito;

            ViewBag.Departamentos = new SelectList(departamentos, "IdDepartamento", "NombreDepartamento", selectedDepartamento);
            ViewBag.Provincias = new SelectList(provincias, "IdProvincia", "NombreProvincia", selectedProvincia);
            ViewBag.Distritos = new SelectList(distritos, "IdDistrito", "NombreDistrito", selectedDistrito);


            return View(oTrabajador);
        }


        [HttpPost]
        public IActionResult Editar(Trabajador oTrabajador)
        {

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
