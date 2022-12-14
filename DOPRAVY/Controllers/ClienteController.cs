using System;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DOPRAVY.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;


namespace DOPRAVY.Controllers
{
    public class ClienteController : Controller
    {
        string BaseUrl = "https://localhost:7128/api/Cliente";

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        public async Task<ActionResult> sesionCli()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("https://localhost:7128/api/Cliente");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;
                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(CliResponse);


                }
                return View(clientes);
            }
        }
        public ActionResult Home()
        {
            return View();
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        public ActionResult registroCli()
        {
            return View();
        }
        [HttpPost]
        public ActionResult registroCli(Cliente cliente)
        {
            using (var client = new HttpClient())
            {

                var postTask = client.PostAsJsonAsync("https://localhost:7128/api/Cliente", cliente);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Home");
                }
            }
            return View(cliente);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        public ActionResult Edit(int cedula)
        {
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync("https://localhost:7197/api/Cliente/" + cedula.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTASKs = result.Content.ReadAsAsync<Cliente>();
                    readTASKs.Wait();
                    cliente = readTASKs.Result;
                }
            }
            return View(cliente);

        }
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                var putTask = client.PutAsJsonAsync($"https://localhost:7128/api/Cliente/{cliente.CliCedula}", cliente);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        public ActionResult Delete(int cedula)
        {
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                var respTask = client.GetAsync("https://localhost:7128/api/Cliente/" + cedula.ToString());
                respTask.Wait();
                var result = respTask.Result;
                if (result.IsSuccessStatusCode)

                {
                    var readTASK = result.Content.ReadAsAsync<Cliente>();
                    readTASK.Wait();
                    cliente = readTASK.Result;
                }
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente, int cedula)
        {
            using (var client = new HttpClient())
            {

                var deleteTask = client.DeleteAsync($"https://localhost:7197/api/Cliente/" + cedula.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

    }
}