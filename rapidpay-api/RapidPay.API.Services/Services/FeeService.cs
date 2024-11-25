using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.Services
{
    public sealed class FeeServiceSingleton
    {
        private static FeeServiceSingleton instance = null;
        private static readonly object lockObject = new object();
        private DateTime lastTimeUpdate = DateTime.UtcNow;
        private double currentFee = 0;
        private static Random random = new Random();
        public FeeServiceSingleton()
        {
            
        }

        public double GetCurrentFee()
        {
            var hours = lastTimeUpdate.Subtract(DateTime.UtcNow).TotalHours;

            if(hours > 1 || currentFee == 0)
            {
               currentFee = random.NextDouble() * 2;
            }

            return currentFee;
        }
        

        public static FeeServiceSingleton Instance
        {
            get
            {
                lock(lockObject)
                {
                    if(instance == null)
                    {
                        instance = new FeeServiceSingleton();
                    }

                    return instance;
                }
            }
        }
    }
}
