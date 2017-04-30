using Nancy;
using Nancy.Helpers;
using SharpTalk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonixTalkNancy
{
    public class FonixModule : NancyModule
    {

        public FonixModule()
            : base("fonix")
        {
            Get["speak"] = request =>
            {
                using (var talkEngine = new FonixTalkEngine())
                {
                    var ms = new MemoryStream();
                    string encodedText = Request.Query.text;
                    string rawText = HttpUtility.UrlDecode(encodedText).Replace(' ', '+');
                    var rawBytes = Convert.FromBase64String(rawText);
                    string text = Encoding.UTF8.GetString(rawBytes);

                    talkEngine.SpeakToWavStream(ms, text);
                    ms.Position = 0;
                    return Response.FromStream(ms, "audio/wav;codec=pcm;rate=11025;bitrate=16");//.WithHeader("Content-Disposition", "attachment; filename = file.wav");
                }  
            };
            
        }
    }
}
