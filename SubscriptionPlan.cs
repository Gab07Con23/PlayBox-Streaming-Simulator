using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBox
{
    public class SubscriptionPlan
    {
        // Private fields
        private string planName;
        private int maxDevices;
        private double price;

        // Constructor
        public SubscriptionPlan(string planName, int maxDevices, double price)
        {
            this.planName = planName;
            this.maxDevices = maxDevices;
            this.price = price;
        }

        // Properties (Encapsulation)
        public string PlanName
        {
            get { return planName; }
        }

        public int MaxDevices
        {
            get { return maxDevices; }
        }

        public double Price
        {
            get { return price; }
        }

        // Method
        public void DisplayPlan()
        {
            Console.WriteLine($"Plan: {planName}, Devices: {maxDevices}, Price: ${price}");
        }
    }
}
