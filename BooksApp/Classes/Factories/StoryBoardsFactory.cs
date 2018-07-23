using UIKit;
namespace BooksApp
{
	public class StoryBoardsFactory
	{
		public StoryBoardsFactory()
		{
		}

		public static UIStoryboard App { get => UIStoryboard.FromName("App", null); }

		
	}
}