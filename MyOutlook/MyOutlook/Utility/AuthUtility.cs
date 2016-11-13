// ***********************************************************************
// FileName:AuthService
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/12 13:04:29
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************


using System.Threading.Tasks;

namespace MyOutlook
{
    public class AuthUtility
    {
        /// <summary>
        /// 用户认证
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> AuthAsync()
        {
            try
            {
                // 已经认证的时候直接获取认证信息
                App.Authentication = await App.PCA.AcquireTokenSilentAsync(Constants.Scopes);
                return true;
            }
            catch
            {
                try
                {
                    // 没有认证的时候重新认证
                    App.Authentication = await App.PCA.AcquireTokenAsync(Constants.Scopes);
                    return true;
                }
                catch
                {
                    // 认证失败
                    return false;
                }
            }
        }
    }
}
