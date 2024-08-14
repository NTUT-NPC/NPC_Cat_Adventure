using CSharp.Model;

namespace CSharp.Controller {
    public class HealthController {
        private static HealthController _instance;
        public Health Health { private set; get; } = new Health();

        public static HealthController Instance {
            get { return _instance ??= new HealthController(); }
        }
    }
}