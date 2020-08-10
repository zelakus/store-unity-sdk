﻿using System;
using UnityEngine;

public static class LoginActionExamples
{
	public static Action<LoginPageEnterController, object> RunDemoUserDelegate => RunDemoUserMethod;
	public static Action<LoginPageEnterController, object> RunSocialAuthDelegate => RunSocialAuthMethod;
	public static Action<LoginPageEnterController, object> RunSteamAuthDelegate => RunSteamAuth;


	private static void RunDemoUserMethod(LoginPageEnterController loginController, object arg = null)
	{
		loginController.GetComponent<DemoUserAuthRunner>().RunDemoUserAuth();
	}

	private static void RunSocialAuthMethod(LoginPageEnterController loginController, object arg)
	{
		SocialProvider provider = (SocialProvider)arg;
		loginController.RunSocialAuth(provider);
	}

	private static void RunSteamAuth(LoginPageEnterController loginController, object arg)
	{
		loginController.RunSteamAuth();
	}
}
