namespace api.Validators.Interfaces {
    public interface IBaseValidator<T> {
        bool isValid(T t);
    }
}