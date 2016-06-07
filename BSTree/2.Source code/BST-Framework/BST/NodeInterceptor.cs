namespace BST
{
    public interface NodeInterceptor
    {
        void preHandle(Node node);
        void postHandle(Node node);
    }
}