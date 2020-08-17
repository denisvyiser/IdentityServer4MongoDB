﻿namespace Project.identityserver.Application.Controller
{
    public class SuccessResponse<TResponseData>
    {
        public bool Success { get { return true; } }

        public TResponseData Data { get; }

        public SuccessResponse(TResponseData data)
        {
            Data = data;
        }
    }
}