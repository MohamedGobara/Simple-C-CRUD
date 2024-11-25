using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class User
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }



        public override string ToString()
        {
            return $"Name:{Name}\tEmail:{Email}\tPhone Number:{Phone_Number}\t";
        }


        /// <summary>
        /// Adds a new user to the provided list of users.
        /// This function prompts the user to enter details (Name, Email, Phone Number),
        /// creates a new User object with the entered data, and adds it to the list.
        /// If the user is successfully added, a confirmation message "User added successfully" is displayed.
        /// If an error occurs during the process, the exception message is displayed to the console. 
        /// </summary>
        /// <param name="Local_Users">
        /// A list of user objects where the new use rwill be added 
        /// </param>

        public void AddUser(List<User> Local_Users)
        {

            WriteLine("Please Enter user in this order (Name ->  Email -> Phone Number");

            try
            {
            // Name validation 
            NameInputLabel:
                Write("Full Name: "); 
                string temprory_name = ReadLine() ?? "Null";
                List<char> myList = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '$','%','^','&','*','(',')','-','+','/','=',
                '~','!'};

                byte Invalid_Flag = 0;
                foreach (var item in temprory_name)
                {
                    if (myList.Contains(item))
                    {
                        Invalid_Flag = 1;
                        break;
                    }
                }
                if (Invalid_Flag == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Enter a valid name only has letters. Numbers and specific characters not allowed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Invalid_Flag = 0;
                    goto NameInputLabel;
                }


                // Email validation
                EmailInputLabel:
                Write("Email Address: ");
                string temprory_email = ReadLine() ?? "Null";
                if (!temprory_email.Contains('@'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Enter a valid mail");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto EmailInputLabel;

                }


                // Phone Numebr validation
                PhoneInputLabel:
                Write("Phone Number: ");
                string temprory_phone = ReadLine()??"Null";
                foreach (var c in temprory_phone) {


                    if (!(c >= '0' && c <= '9')) {
                        Invalid_Flag = 1;
                        break; 

                    }
                
                }

                if (Invalid_Flag == 1) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Enter a valid mobile number witout country code");
                    Console.ForegroundColor = ConsoleColor.White;
                    Invalid_Flag = 0;
                    goto PhoneInputLabel; 
                }

                // Add new user in list after taking data from the user 
                Local_Users.Add(new User()
                {

                    Name =temprory_name,
                    Email = temprory_email,
                    Phone_Number = temprory_phone  

                });



                // print this messege if we confirmed the user is added 
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("The User added successfully");
                Console.ForegroundColor = ConsoleColor.White;


            }
            // catch any exception may occourd 
            catch (Exception ex)
            {

                WriteLine($"An error occourd:{ex.Message}");
            }


        }

        /// <summary>
        /// Updates a user's information in the provided list of users.
        /// </summary>
        /// <param name="Local_Users">A list of users where the update operation will be performed.</param>
        /// <remarks>
        /// The method searches for a user by their phone number. If a match is found, 
        /// it prompts the user to select which field (Name, Email, or Phone Number) to update.
        /// If no user is found with the given phone number, a message is displayed.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// var users = new List<User>();
        /// users.Add(new User { Name = "John", Email = "john@example.com", Phone_Number = "1234567890" });
        /// Update_User(users);
        /// </code>
        /// </example>
        /// <exception cref="FormatException">Thrown when the user input for choice is not a valid number.</exception>
        public void Update_User(List<User> Local_Users)
        {
            // Prompt the user to enter the phone number of the user they want to update
            WriteLine("Enter the user's phone number");

            // Read the input and assign it to the variable `phone`
            string phone = ReadLine();

            // Search for the user in the list by matching the phone number
            User Found_user = Local_Users.FirstOrDefault<User>(newUser => newUser.Phone_Number == phone);

            if (Found_user != null)
            {
                // If the user is found, ask which field they want to update
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("User exists, please choose which data you need to update");
                Console.ForegroundColor = ConsoleColor.White;
                WriteLine("1. Name\n2. Email\n3. Phone Number");

                // Read the user's choice and convert it to an integer
                var choice = Convert.ToInt32(ReadLine());

                // Handle the user's choice using a switch statement
                switch (choice)
                {
                    case 1:
                        // Update the user's name
                        WriteLine("Enter Name:");
                        Found_user.Name = ReadLine();
                        break;
                    case 2:
                        // Update the user's email
                        WriteLine("Enter Email:");
                        Found_user.Email = ReadLine();
                        break;
                    case 3:
                        // Update the user's phone number
                        WriteLine("Enter Phone Number:");
                        Found_user.Phone_Number = ReadLine();
                        break;
                    default:
                        // Handle invalid choices
                        WriteLine("Please enter a correct choice.");
                        break;
                }
            }
            else
            {
                // If no user with the specified phone number is found, display a message
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("User not found!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        /// <summary>
        /// Deletes a user from the provided list of users based on their phone number.
        /// </summary>
        /// <param name="Local_Users">The list of users to search and delete from.</param>
        /// <remarks>
        /// This method prompts the user to enter a phone number, searches the list for a user with the specified phone number, 
        /// and removes the user if found. If no user is found, a message is displayed.
        /// </remarks>
        public void Delete_User(List<User> Local_Users)
        {
            // Prompt the user to enter the phone number of the user they want to delete
            WriteLine("Enter the user's phone number");

            // Read the input phone number and assign it to the variable `phone`
            string phone = ReadLine();

            // Search for the user in the list by matching the phone number
            User Found_user = Local_Users.FirstOrDefault(newUser => newUser.Phone_Number == phone);

            if (Found_user != null)
            {
                // If the user is found, remove them from the list
                Local_Users.Remove(Found_user);

                // Confirm that the user was successfully deleted
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("User deleted successfully");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                // If no user with the specified phone number is found, display a message
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("User not found!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void Print_All_Users(List<User> Local_Users)
        {

            int counter = 1;

            if (Local_Users.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var user in Local_Users)
                {

                    WriteLine($"{counter++}." + user);

                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            else {

                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("No users found");
                Console.ForegroundColor = ConsoleColor.White;

            }



        }

    }
}

