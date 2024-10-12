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
        private static Stack<ContentView> _contentViews = new Stack<ContentView>();
        public static event EventHandler ContentViewChanged;
        public static event EventHandler<ContentView> CurrentViewChanged;
        public static ContentView GetCurrentView()
        {
            return currentPage;
        }
        public static void SetCurrentPage(ContentView contentPage)
        {
            _contentViews.Push(currentPage);
            currentPage = contentPage;
            ContentViewChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SetPreviousView()
        {
            currentPage = _contentViews.Pop();
        }
    }
}
