using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmallTeste.AppService.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrmallTeste.Api.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotifierAppService _notifier;
        public MainController(INotifierAppService notifier)
        {
            _notifier = notifier;

        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModel(modelState);

            return CustomResponse();
        }

        protected void NotifyInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(x => x.Value.Errors.Count > 0).ToList();
            foreach (var erro in errors)
            {
                ErrorNotifier(erro.Key, erro.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
            }
        }

        protected void ErrorNotifier(string property, string message)
        {
            _notifier.Handle(new NotificationMessage(property, message));
        }
    }
}
