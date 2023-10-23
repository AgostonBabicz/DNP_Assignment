using Application.DaoInterfaces;

namespace Application.Logic;

public class CommentLogic
{
    private readonly ICommentDao _commentDao;

    public CommentLogic(ICommentDao commentDao)
    {
        _commentDao = commentDao;
    }
    
    
}