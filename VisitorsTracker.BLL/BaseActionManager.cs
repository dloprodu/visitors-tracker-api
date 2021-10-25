using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsTracker.BLL
{
    public abstract class BaseActionManager<TInput, TResult>
        where TInput: ActionInput
        where TResult: class
    {
        protected TInput _input;

        public BaseActionManager()
        {
        }

        public BaseActionManager(TInput input)
        {
            this._input = input;
        }

        public abstract TResult DoAction();
    }
}
