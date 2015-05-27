using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearcher
{
    /// <summary>
    /// Main class for View Model
    /// TODO: follow guidelines
    /// </summary>
    public class TextViewModel :ITextViewModel
    {
        private readonly IDispatcher _dispatcher;
        
        public TextViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// 
        public List<String> lista=new List<String>();
        public void Search()
        {
            if (!String.IsNullOrEmpty(Content) && !String.IsNullOrEmpty(Query))
            {
                var a = Content.Split();
                var b = 0;
                foreach (var item in a)
                {
                    if (SelectedMethod.VerifyText(item)) b++;
                }
                if (b == 0) SearchResult = Globals.NoSearchResults;
                else SearchResult = String.Format("Results found: {0}", Globals.ResultsFound);
                lista.Add(Query);
            }
        }
        public string Query
        {
            get
            {
              //  throw new NotImplementedException();
                return null;
            }
            set
            {
              ///  throw new NotImplementedException();
                RaisePropertyChanged("Query");
                Search();
            }
        }

        public string Content
        {
            get
            {
                return Globals.LoremIpsum;
            }
            set
            {
               // throw new NotImplementedException();
                RaisePropertyChanged("Content");
                Search();
            }
        }

        public System.Windows.Input.ICommand SearchCommand
        {
            get {
              //  throw new NotImplementedException(); 
              //  return new MyCommand(null);//?
                return null;
            }
        }

        public string SearchResult
        {
            get
            {
           //     throw new NotImplementedException();
                return null;
            }
            set
            {
                RaisePropertyChanged("SearchResult");
           //     throw new NotImplementedException();
            }
        }

        public System.Windows.Input.ICommand SaveSearchesCommand
        {
            get {
              //  throw new NotImplementedException(); 
                return null;
            }
        }

        public ASearcher SelectedMethod
        {
            get
            {
                return SearchMethods.First<ASearcher>();
            }
            set
            {
             //   throw new NotImplementedException();
                RaisePropertyChanged("SelectedMethod");
            }
        }

        public IEnumerable<ASearcher> SearchMethods
        {
            get 
            {
                return new List<ASearcher> { new ContainsSearcher(), new StartsWithSearcher()};
            }
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
