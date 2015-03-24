namespace LA3.Model
{
    public partial class AccountStatus
    {
        public bool IsCreated { get { return Status.ToLower().Trim() == "created"; } }
        public bool IsDeleted { get { return Status.ToLower().Trim() == "deleted"; } }
        public bool IsCompleted { get { return Status.ToLower().Trim() == "completed"; } }
    }
}
