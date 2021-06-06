using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace ExamenFinalP1
{
    class Program
    {
        static ITelegramBotClient _botclient;

      

        static void Main(string[] args)
        {
            _botclient = new TelegramBotClient("1730925501:AAFHkAJhqqud054klnSLw35RRwoOtn42ZpM");

            var me = _botclient.GetMeAsync().Result;
            Console.WriteLine($"Hola yo soy {me.Id} y mi nmbre es {me.FirstName}");

            _botclient.OnMessage += _botclient_OnMessage;

            _botclient.StartReceiving();

            Console.WriteLine("Porfavor precione cualquier tecla    para salir");
            Console.ReadKey();

            _botclient.StopReceiving();


        }

        private async static void _botclient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Mensaje Resivido");

                

                if (e.Message.Text.ToLower().Contains("hola"))
                {
                    await _botclient.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: "Gracias Por comunicarte con nosotros.\n\n" +
                    "Escribe *menu* para saber las opciones.\n");

                }

                else if(e.Message.Text.ToLower().Contains("menu"))
                {
                    await _botclient.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: $"Escribe :  *video* para verlo.\n" +
                    "Escribe :  *sticker* para verlo.\n" +
                    "Escribe :  *animacion* para verlo.\n" +
                    "Escribe :  *contacto* para ver el contacto del creador.\n" +
                    "Escribe: *documento* para verlo.\n" +
                    "Escribe: *imagen* para verla.\n");


                }

                else if (e.Message.Text.ToLower().Contains("sticker"))
                {
                    await _botclient.SendStickerAsync(
                    chatId: e.Message.Chat.Id,
                    sticker: "https://tlgrm.es/_/stickers/17b/046/17b0463c-7ca1-3d38-8e6b-c176a2c767c1/1.webp"
                    ); 


                }

                else if (e.Message.Text.ToLower().Contains("animacion"))
                {
                    await _botclient.SendAnimationAsync(
                   chatId: e.Message.Chat.Id,
                   animation: "https://tlgrm.es/_/stickers/bec/f45/becf45d6-eb16-4fac-bc7a-6007142701c6/thumb-animated-128.mp4"

                   );


                }

                else if (e.Message.Text.ToLower().Contains("documento"))
                {
                    await _botclient.SendDocumentAsync(
                   chatId: e.Message.Chat.Id,
                   document : "C:/Users/OscarEstid/OneDrive/Escritorio/Telegram/crudDB.pdf"
                   );


                }

                else if (e.Message.Text.ToLower().Contains("video"))
                {
                    await _botclient.SendVideoAsync(
                   chatId: e.Message.Chat.Id,
                   video: "https://res.cloudinary.com/dherrerap/video/upload/v1560039252/WhatsApp_Video_2019-06-08_at_6.10.54_PM.mp4"

                   );


                }


                else if (e.Message.Text.ToLower().Contains("imagen"))
                {
                    await _botclient.SendPhotoAsync(
                   chatId: e.Message.Chat.Id,
                   photo : "https://imag.malavida.com/articulos/normal-size/telegram-4cafed61-20170705-pca.jpg"

                   );


                }

                else if (e.Message.Text.ToLower().Contains("contacto"))
                {
                    await _botclient.SendContactAsync(
                   chatId: e.Message.Chat.Id,
                   phoneNumber: "+502 33356063",
                   firstName: "Oscar",
                   lastName: "Corado"
                   );


                }





            }
        }
    }
}
