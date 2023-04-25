using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.Rating = 0;

        }
        public string FirstName 
        {
            get { return firstName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                } 

                firstName = value;
            }
        }

        public string LastName 
        { 
             get { return lastName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }

                lastName = value;
            }
        }

        public double Rating 
        {
            get { return  rating; }
            private set { rating = value; }
            
        }

        public string DrivingLicenseNumber 
        {
            get { return drivingLicenseNumber; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked { get; private set; } = false;

        public void DecreaseRating()
        {
            this.Rating -= 2.0;
            if (this.Rating < 0.0)
            {
                this.Rating = 0.0;
                this.IsBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;
            if (this.Rating > 10.0)
            {
                this.Rating = 10.0;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";
        }
    }
}
