global using System;
global using static System.Console;
using CRUD;
using System.Security.Cryptography;



namespace Program
{

    class Program
    {


        public static void Main()
        {


            List<User> MyUsers_List = new List<User>() ;

            User MyUsers = new User();


            while (true) {

                WriteLine("1-Add user\n2-Update data of user\n3-Delete User\n4-Print all users");

                Write("Enter chooice(1/2/3/4): ");

                UInt32 input_choice = Convert.ToUInt32(ReadLine());


                switch (input_choice) {


                    case 1:
                        MyUsers.AddUser(MyUsers_List);
                        break;
                    case 2:
                        MyUsers.Update_User(MyUsers_List);
                        break;
                    case 3:
                        MyUsers.Delete_User(MyUsers_List);
                        break;
                    case 4:
                        MyUsers.Print_All_Users(MyUsers_List);
                        break;
                    default:
                        WriteLine("Please Enter valid choice");
                        break; 




                }






            }

        }


    }


}