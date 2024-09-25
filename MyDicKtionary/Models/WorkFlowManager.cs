using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Models
{
    static class WorkFlowManager
    {
        private static ContentView currentPage;
        public static ContentView GetCurrentView()
        {
            return currentPage;
        }
        public static void SetCurrentPage(ContentView contentPage)
        {
            currentPage = contentPage;
        }
    }
}
