using Blog.Models;
using Microsoft.Data.SqlClient;
using Blog.Data;

namespace Blog.Screens
{
    public class CScreens
    {
        private SqlConnection _connection { get; set; }
        public CScreens(SqlConnection connection)
        {
            _connection = connection;
        }
        public void HomeScreen()
        {

            var options = new[] {
                "Usuário",
                "Perfis",
                "Categoria",
                "Tag",
                "Post",
                "Vincular perfil e usuario",
                "Vincular post e tag",
                "Relatórios"
            };
            var count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    this.UserScreen();
                    break;
                case 2:
                    this.RoleScreen();
                    break;
                case 3:
                    this.CategoryScreen();
                    break;
                case 4:
                    this.TagScreen();
                    break;
                case 5:
                    this.PostScreen();
                    break;
                case 6:
                    this.RoleAndUserScreen();
                    break;
                case 7:
                    this.TagAndPostScreen();
                    break;
                case 8:
                    this.AnalyticsScreen();
                    break;
                default:
                    break;
            }
        }

        public void UserScreen()
        {
            var options = new[] {
                "Criar Usuário",
                "Listar Usuários"
            };
            int count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            var controller = new UserController();
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    controller.CreateUser(_connection);
                    break;
                case 2:
                    controller.ListUsers(_connection);
                    break;
                default:
                    break;
            }
        }
        public void RoleScreen()
        {
            var options = new[] {
                "Criar Role",
                "Vincular Role e Usuario"
            };
            int count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            var controller = new PostController();
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    controller.CreatePost(_connection);
                    break;
                case 2:
                    controller.VincularPost(_connection);  
                    break;
                default:
                    break;
            }
        }

        public void CategoryScreen()
        {
            var options = new[] {
                "Criar Categoria",
                "Listar Categorias e Seus Respectivos Posts."
            };
            int count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            var controller = new CategoryController();
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    controller.CreateCategory(_connection);
                    break;
                case 2:
                    controller.ListCategories(_connection);
                    break;
                default:
                    break;
            }
        }

        public void TagScreen()
        {
           var options = new[] {
                "Criar Tag"
            };
            int count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            var controller = new TagController();
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    controller.CreateTag(_connection);
                    break;
                default:
                    break;
            }
        }

        public void PostScreen()
        {
           var options = new[] {
                "Criar Post",
                "Vincular Post a Tag"
            };
            int count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"[{count}] - {option}");
                count++;
            }
            var controller = new PostController();
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    controller.CreatePost(_connection);
                    break;
                case 2:
                    controller.VincularPost(_connection);
                    break;
                    default:
                    break;
            }
        }
        public void RoleAndUserScreen()
        {
            var options = new[] {
                "Criar Usuário"
            };
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }

        public void TagAndPostScreen()
        {
            var options = new[] {
                "Criar Usuário"
            };
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }

        public void AnalyticsScreen()
        {
            var options = new[] {
                "Criar Usuário"
            };
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}