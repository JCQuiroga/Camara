using System;
using System.Threading.Tasks;
using ContactosModel.Model;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace Camara
{
    public class UploadFile
    {
        string url = "http://apicontactos-jcq.azurewebsites.net/api/camera";

        public async Task<string> SubirFoto(byte[] file)
        {
            var client = new RestClient(url);

            var request = new RestRequest();
            request.Method=Method.POST;

            var d = new FotosModel()
            {
                Data = Convert.ToBase64String(file),
                id =33 //El ID ahora no importa.
            };
            request.AddJsonBody(d);
            var r = await client.Execute<string>(request);
            return r.Data;
        }

    }
}