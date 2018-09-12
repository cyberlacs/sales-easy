namespace Sales.Infrastructure
{
    using ViewModels;//Parte 07

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }//Parte 07

        public InstanceLocator()
        {
            this.Main = new MainViewModel();//Parte 07
        }
    }
}
