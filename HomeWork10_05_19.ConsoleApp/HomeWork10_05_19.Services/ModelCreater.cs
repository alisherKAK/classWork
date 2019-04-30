using HomeWork10_05_19.DataAccess;
using HomeWork10_05_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10_05_19.Services
{
    public static class ModelCreater
    {
        public static Theme CreateThemeAndSave()
        {
            Theme newTheme = new Theme()
            {
                Name = SetInformation.SetName()
            };

            TableDataService<Theme> dataService = new TableDataService<Theme>();
            if(dataService.GetAll().All(theme => theme.Name != newTheme.Name))
            {
                dataService.Add(newTheme);
                return newTheme;
            }

            throw new Exception("This theme already exists");
        }

        public static NewsAuthor CreateNewsAuthorAndSave()
        {
            NewsAuthor newNewsAuthor = new NewsAuthor()
            {
                Name = SetInformation.SetName()
            };

            TableDataService<NewsAuthor> dataService = new TableDataService<NewsAuthor>();
            if (dataService.GetAll().All(newsAuthor => newsAuthor.Name != newNewsAuthor.Name))
            {
                dataService.Add(newNewsAuthor);
                return newNewsAuthor;
            }
            
            throw new Exception("This news author already exists");
        }

        public static CommentAuthor CreateCommentAuthorAndSave()
        {
            CommentAuthor newCommentAuthor = new CommentAuthor()
            {
                Name = SetInformation.SetName()
            };

            TableDataService<CommentAuthor> dataService = new TableDataService<CommentAuthor>();
            if (dataService.GetAll().All(commentAuthor => commentAuthor.Name != newCommentAuthor.Name))
            {
                dataService.Add(newCommentAuthor);
                return newCommentAuthor;
            }

            throw new Exception("This comment author already exists");
        }
    }
}
