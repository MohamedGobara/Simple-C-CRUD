// Global using directives for necessary namespaces
global using System;
global using static System.Console;
using CRUD; // Importing the CRUD namespace where User class is defined
using System.Security.Cryptography; // Not currently used but might be useful for encryption or security-related tasks

namespace Program
{
    class Program
    {
        // Main entry point of the application
        public static void Main()
        {
            // Initialize an empty list to store users
            List<User> MyUsers_List = new List<User>();

            // Create a new instance of the User class
            User MyUsers = new User();

            // Infinite loop to continuously show the menu until the program is exited manually
            while (true)
            {
                // Display the menu with options for user actions
                WriteLine("1-Add user\n2-Update data of user\n3-Delete User\n4-Print all users");

                // Prompt the user to enter their choice
                Write("Enter choice(1/2/3/4): ");

                // Read the user's choice and convert it to an unsigned integer
                UInt32 input_choice = Convert.ToUInt32(ReadLine());

                // Use a switch statement to handle the user's choice
                switch (input_choice)
                {
                    // Case for adding a new user
                    case 1:
                        MyUsers.AddUser(MyUsers_List); // Call the AddUser method from the User class
                        break;

                    // Case for updating an existing user's data
                    case 2:
                        MyUsers.Update_User(MyUsers_List); // Call the Update_User method from the User class
                        break;

                    // Case for deleting a user
                    case 3:
                        MyUsers.Delete_User(MyUsers_List); // Call the Delete_User method from the User class
                        break;

                    // Case for printing all the users in the list
                    case 4:
                        MyUsers.Print_All_Users(MyUsers_List); // Call the Print_All_Users method from the User class
                        break;

                    // Default case if the user enters an invalid choice
                    default:
                        WriteLine("Please Enter a valid choice"); // Inform the user that their choice was invalid
                        break;
                }
            }
        }
    }
}
