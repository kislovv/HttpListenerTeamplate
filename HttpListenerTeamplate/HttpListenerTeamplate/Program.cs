using System.Net;
using System.Text;

var httpListener = new HttpListener();
httpListener.Prefixes.Add("http://localhost:5000/");


httpListener.Start();
while (httpListener.IsListening)
{
    var context = await httpListener.GetContextAsync();
    var response = context.Response;
    var request = context.Request;
    _ = Task.Run(async () =>
    {
        await response.OutputStream.WriteAsync(
            Encoding.UTF8.GetBytes("Hello World!"));
        
        response.OutputStream.Close();
        response.Close();
    });
}
httpListener.Stop();
httpListener.Close();
