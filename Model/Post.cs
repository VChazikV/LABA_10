using System.Drawing;

namespace Model
{
    public class Post : IInit, IRandomInit, IShow
    {
        #region Атрибуты
        string color;
        /// <summary>
        /// Название Поста
        /// </summary>
        string name;//Кол-во просмотров

        /// <summary>
        /// Просмотры
        /// </summary>
        int numViews;//Кол-во просмотров

        /// <summary>
        /// Комментарии
        /// </summary>
        int numComments;//Кол-во комментариев

        /// <summary>
        /// Реакции
        /// </summary>
        int numReactions;//Кол-во реакций

        static int SUBSCRIBERS = 1000;//Константа для кол-во подписчиков

        static int countOfPosts = 0;//Кол-во постов

        static int countOfUnnamedPosts = 0;//Кол-во постов без названия
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство для обработки бизнес-правил для кол-ва просмотров на посте
        /// </summary>
        public string Name
        {
            get => name;

            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    name = $"POST_{++countOfUnnamedPosts}";
                }
            }
        }
        /// <summary>
        /// Свойство для обработки бизнес-правил для кол-ва просмотров на посте
        /// </summary>
        public int Views
        {
            get => numViews;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Views), "Кол-во просмотров не может быть меньше 0");
                }
                numViews = value;
            }
        }

        /// <summary>
        /// Свойство для обработки бизнес-правил для кол-ва комментариев на посте
        /// </summary>
        public int Comments
        {
            get => numComments;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Comments), "Кол-во комментариев не может быть меньше 0");
                }
                numComments = value;
            }
        }
        /// <summary>
        /// Свойство для обработки бизнес-правил для кол-ва реакций на посте
        /// </summary>
        public int Reactions
        {
            get => numReactions;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Reactions), "Кол-во реакций не может быть меньше 0");
                }
                numReactions = value;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор всех атрибутов
        /// </summary>
        public Post(string name, int numViews, int numComments, int numReactions)
        {
            Name = name;
            Views = numViews;
            Comments = numComments;
            Reactions = numReactions;
            countOfPosts++;
        }
        /// <summary>
        /// Конструктор без атрибутов
        /// </summary>
        public Post()
        {
            Name = "";
            Views = 0;
            Comments = 0;
            Reactions = 0;
            countOfPosts++;
        }
        /// <summary>
        /// Конструктор копирования
        /// </summary>
        public Post(Post p)
        {
            Name = p.Name;
            Views = p.Views;
            Comments = p.Comments;
            Reactions = p.Reactions;
            countOfPosts++;
        }
        #endregion

        #region Операции 1 части
        /// <summary>
        /// Вывод информации об объекте в формате "{ИМЯ} N просмотров. M комментариев. Z реакций."
        /// </summary>
        public static string ShowInfoOfPost(Post post)
        {
            if (post is null)
            {
                return "";
            }
            return 
                ($"------------------------------------\n" +
                $"{post.Name}\n" +
                $"{post.Views} {GetWordForm(post.Views, "просмотр", "просмотра", "просмотров")}.\n" +
                $"{post.Comments} {GetWordForm(post.Comments, "комментарий", "комментария", "комментариев")}.\n" +
                $"{post.Reactions} {GetWordForm(post.Reactions, "реакция", "реакции", "реакций")}.\n" +
                $"------------------------------------\n");
        }
        /// <summary>
        /// Вывод информации о кол-ве объектов.
        /// </summary>
        public static string ShowCountOfPosts()
        {
            return ($"Кол-во постов {countOfPosts}\n");
        }
        /// <summary>
        /// Вывод информации о информации объекта.
        /// </summary>
        public string ShowCoefficientOfEngagement()
        {
            double countOfEngagement = (float)Views / SUBSCRIBERS;
            countOfEngagement = Math.Round(countOfEngagement, 2);
            if (countOfEngagement > 1)
            {
                return ($"Коэффициент вовлечённости поста {Name} равен {countOfEngagement}\n");
            }
            else if (countOfEngagement < 1)
            {
                return ($"Коэффициент вовлечённости поста {Name} равен {countOfEngagement}\n");
            }
            else
            {
                return ($"Коэффициент вовлечённости поста {Name}  равен {countOfEngagement}\n");
            }
        }
        public static string ShowCoefficientOfEngagement(Post postCurrent)
        {
            double countOfEngagement = (double)postCurrent.Views / (double)SUBSCRIBERS;
            countOfEngagement = Math.Round(countOfEngagement, 2);
            if (countOfEngagement > 1)
            {
                return ($"Коэффициент вовлечённости поста {postCurrent.Name} равен {countOfEngagement}\n");
            }
            else if (countOfEngagement < 1)
            {
                return ($"Коэффициент вовлечённости поста {postCurrent.Name} равен {countOfEngagement}\n");
            }
            else
            {
                return ($"Коэффициент вовлечённости поста {postCurrent.Name} равен {countOfEngagement}\n");
            }
        }
        public static double ShowCoefficientOfEngagement3Part(Post postCurrent)
        {
            double countOfEngagement = (double)postCurrent.Views / (double)SUBSCRIBERS;
            countOfEngagement = Math.Round(countOfEngagement, 2);
            return countOfEngagement;
        }
        #endregion

        #region Операции 2 Часть
        public static Post operator ++(Post currentPost)
        {
            Post resultPost = new Post(currentPost);
            resultPost.Views = resultPost.Views + 1;
            return resultPost;
        }
        public static Post operator !(Post currentPost)
        {
            Post resultPost = new Post(currentPost);
            resultPost.Reactions = resultPost.Reactions + 1; //Этот вариант не работает из-за обработки оператора ! не как ++ и --
            return resultPost;

            //Нарушим правила обработки унарных операций и будем изменять сам операнд
            //currentPost.Reactions +=1;
            //return currentPost;

        }
        public static explicit operator bool(Post currentPost)
        {
            return (currentPost.Views > 0) && (currentPost.Reactions >= 1 || currentPost.Comments >= 1);
        }
        public static implicit operator double(Post currentPost)
        {
            return Math.Round((double)currentPost.Views / (double)SUBSCRIBERS, 2);
        }
        public static bool operator ==(Post p1, Post p2)
        {
            return p1.Name == p2.Name && p1.Views == p2.Views && p1.Comments == p2.Comments && p1.Reactions == p2.Reactions;
        }
        public static bool operator !=(Post p1, Post p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Post other = (Post)obj;
            return Views == other.Views &&
                   Comments == other.Comments &&
                   Reactions == other.Reactions &&
                   Name == other.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Views, Comments, Reactions);
        }
        #endregion

        #region Вспомогательные функции
        private static string GetWordForm(int countOfItem, string normal, string singlForm, string pluralForm)//Вспомогательный метод, для нахождения формы слова
        {
            string corкectForm;
            countOfItem = countOfItem % 100;
            int lastNumber = countOfItem % 10;
            if (countOfItem > 10 && countOfItem < 20)
            {
                corкectForm = pluralForm;
            }
            else if (lastNumber >= 2 && lastNumber <= 4)
            {
                corкectForm = singlForm;
            }
            else if (lastNumber == 1)
            {
                corкectForm = normal;
            }
            else
            {
                corкectForm = pluralForm;
            }
            return corкectForm;
        }
        #endregion

        #region 10 Лаба
        public static int GetCountOfItem()
        {
            return countOfPosts;
        }
        public void RandomInit()
        {

            Random random = new Random();
            Name = "Случайное имя";
            Views = random.Next(1, 1001);
            Reactions = random.Next(1, 1000);
            Comments = random.Next(1, 1000);
        }

        public void Init(string nameOfPost, int viewsOfPost, int reactionsOfPost, int commentsOfPost)
        {
            Name = nameOfPost;
            Views = viewsOfPost;
            Reactions = reactionsOfPost;
            Comments = commentsOfPost;
        }

        public string[] Show()//Вывод данных объекта
        {
            return ["Name", Name.ToString(), "Views", Views.ToString(), "Reactions", Reactions.ToString(), "Comments", Comments.ToString()];
        }

        public void Init(string nameOfPlant, string colorOfPlant, int? heightOfTree)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }
        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }
        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant, bool? hasThrons)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }
        public void Init(string nameOfPlant, string colorOfPlant)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }
        #endregion
    }
}
