using MessageTest.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageTest.Hubs
{
    public class MessageHub:Hub
    {
        public static List<UserDetail> userDetailList = new List<UserDetail>();
        public async Task SendMessage(string user, string message)
        {
            var userDetail = userDetailList.Where(x => x.UserName == user).FirstOrDefault();
            await Clients.Client(userDetail.ConnectionId).SendAsync("ShowMessage",message);
        }

        public void ListeKisiEkle(string kullaniciAdi)
        {
            if (userDetailList.Exists(x => x.UserName == kullaniciAdi))
            {
                userDetailList.Where(x => x.UserName == kullaniciAdi).ToList().ForEach(s => s.ConnectionId = Context.ConnectionId);
            }
            else
            {
                userDetailList.Add(new UserDetail
                {
                    UserName = kullaniciAdi,
                    ConnectionId = Context.ConnectionId
                });
            }
        }
    }
}
