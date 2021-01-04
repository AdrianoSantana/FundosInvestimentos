using System;

namespace FundosInvestimentos.Models
{
    public class BaseModel
    {
        public BaseModel()
        {

        }
        public BaseModel(Guid id, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}