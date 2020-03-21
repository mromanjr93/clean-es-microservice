namespace Shared.Domain.Entities
{
    public interface IActiveEntity
    {
        #region Properties
        bool? Active { get; set; }
        #endregion
    }
}