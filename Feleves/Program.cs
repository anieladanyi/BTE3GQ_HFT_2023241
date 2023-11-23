using System;
using System.Linq;
using BTE3GQ_HFT_2023241.Models;
using BTE3GQ_HFT_2023241.Repository;

namespace Feleves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            
            var items = context.Players.ToArray();
            var ucls = context.UCLs.ToArray();
            ;
        }
    }
}
