namespace Micro.Async.Grade.Persistance
{
    public interface IMessageBroker
    {

        // kada se doda nova ocena , da se obavesti student da se dodala ocena
        void Publish<T> (T message);

    }
}
