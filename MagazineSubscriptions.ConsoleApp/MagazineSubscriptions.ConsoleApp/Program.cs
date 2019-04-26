using MagazineSubscriptions.Models;
using MagazineSubscriptions.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscriptions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User currentUser = new User();
            bool isFinish = false;

            if (bool.Parse(ConfigurationManager.AppSettings["IsAdmin"]))
            {
                do
                {
                    switch (Menu.AdminMenu())
                    {
                        case AdminAction.AddMagazine:
                            AdminServices.CreateMagazine();
                            break;
                        case AdminAction.MakeReport:
                            switch (Menu.ChoseReport())
                            {
                                case ReporstType.EarningReport:
                                    AdminServices.MakeEarningsRepors();
                                    break;
                                case ReporstType.SubsReport:
                                    AdminServices.MakeSubsRepors();
                                    break;
                            }
                            break;
                        case AdminAction.Exit:
                            isFinish = true;
                            break;
                    }
                } while (!isFinish);
            }
            else
            {
                do
                {
                    switch (Menu.UserMenu())
                    {
                        case Services.UserAction.Entry:
                            currentUser = Menu.Entry();
                            switch (Menu.ChoiseMenu())
                            {
                                case Choises.AddSub:
                                    SubsritionsType subsritionsType = Menu.ChoseSubscription(currentUser);
                                    var userSubs = OperationWithSubscriptions.AddSubsription(currentUser, subsritionsType);
                                    AdminServices.CreateMagazineShipping(userSubs);
                                    break;
                                case Choises.DelSub:
                                    OperationWithSubscriptions.DeleteSubsription(currentUser);
                                    break;
                                default:
                                    Console.WriteLine("Нет такого действия, выберите из предложеных");
                                    break;
                            }
                            break;
                        case Services.UserAction.Registration:
                            Menu.RegistrationMenu();
                            break;
                        case Services.UserAction.Exit:
                            isFinish = true;
                            break;
                        default:
                            Console.WriteLine("Нет такого действия, выберите из предложеных");
                            break;
                    }
                } while (!isFinish);
            }
        }
    }
}
