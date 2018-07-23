using UIKit;
namespace BooksApp
{
    /// <summary>
    /// Factory para los storyboard del proyecto
    /// </summary>
	public class StoryBoardsFactory
	{
		public StoryBoardsFactory()
		{
		}

		public static UIStoryboard App { get => UIStoryboard.FromName("App", null); }

		
	}
}