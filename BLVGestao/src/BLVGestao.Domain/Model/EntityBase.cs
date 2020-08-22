using System;

namespace BLVGestao.Domain.Model
{
    //TODO:Verificar necessidade desta classe
    public class EntityBase
    {
        public EntityBase(bool ativo)
        {
            Ativo = ativo;
        }
        public bool Ativo { get; private set; }

        public void Inativar()
        {
            Ativo = false;
        }
        public void Ativar()
        {
            Ativo = true;
        }
    }
}
