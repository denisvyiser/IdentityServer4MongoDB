using Project.identityserver.Domain.Models;
using Project.identityserver.Repository.Test.Validations;
using System;


namespace Project.identityserver.Repository.Test.FakeModels
{
    public class DemoModelFake : DemoModel
    {
        public DemoModelFake(Guid id,string description):base(id == Guid.Empty ? Guid.NewGuid() : id, description)
        {
            
        }

    //    public override bool IsValid()
    //{
    //    return new DemoModelValidacao().Validate(this).IsValid;
    //}

    
}
}
