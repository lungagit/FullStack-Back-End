using FullStack.Data;
using FullStack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.App
{
    class Program
    {
        private static readonly FullStackDbContext _context = new FullStackDbContext();
        static void Main(string[] args)
        {
            //InsertFreeState();
            //InsertGauteng();
            //InsertKZN();
            //InsertMpumalanga();
            //InsertWC();

            Console.WriteLine("\nApp is running....press any key to exit");
            Console.ReadLine();

        }
        //private static void InsertFreeState()
        //{
        //    var province = new Province
        //    {
        //        Name = "Free State",
        //        Cities = new List<City>()
        //        {
        //            new City
        //            {
        //                Name = "Bloemfontein"
        //            },

        //            new City
        //            {
        //                Name = "Welkom"
        //            },

        //        }
        //    };

        //    _context.Add(province);
        //    _context.SaveChanges();
            
        //}

        //private static void InsertGauteng()
        //{
        //    var province = new Province
        //    {
        //        Name = "Gauteng",
        //        Cities = new List<City>()
        //        {
        //            new City
        //            {
        //                Name = "Johannesburg"
        //            },

        //            new City
        //            {
        //                Name = "Pretoria"
        //            },

        //        }
        //    };

        //    _context.Add(province);
        //    _context.SaveChanges();

        //}

        //private static void InsertMpumalanga()
        //{
        //    var province = new Province
        //    {
        //        Name = "Mpumalanga",
        //        Cities = new List<City>()
        //        {
        //            new City
        //            {
        //                Name = "Nelspruit"
        //            },

        //            new City
        //            {
        //                Name = "White River"
        //            },

        //        }
        //    };

        //    _context.Add(province);
        //    _context.SaveChanges();

        //}

        //private static void InsertKZN()
        //{
        //    var province = new Province
        //    {
        //        Name = "KwaZulu Natal",
        //        Cities = new List<City>()
        //        {
        //            new City
        //            {
        //                Name = "Pietermaritzburg"
        //            },

        //            new City
        //            {
        //                Name = "Durban"
        //            },

        //        }
        //    };

        //    _context.Add(province);
        //    _context.SaveChanges();

        //}

        //private static void InsertWC()
        //{
        //    var province = new Province
        //    {
        //        Name = "Western Cape",
        //        Cities = new List<City>()
        //        {
        //            new City
        //            {
        //                Name = "Cape Town"
        //            },

        //            new City
        //            {
        //                Name = "Stellenbosch"
        //            },

        //        }
        //    };

        //    _context.Add(province);
        //    _context.SaveChanges();

        //    Console.WriteLine("Done inserting provinces....");

        //}

    }
}

