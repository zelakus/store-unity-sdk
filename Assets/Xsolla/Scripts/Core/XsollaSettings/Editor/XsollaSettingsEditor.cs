﻿using UnityEditor;
using UnityEngine;
using Xsolla.PayStation;
using Xsolla.Store;

namespace Xsolla.Core
{
	[CustomEditor(typeof(XsollaSettings))]
	public class XsollaSettingsEditor : UnityEditor.Editor
	{
		const string LoginIdTooltip = "Login ID from your Publisher Account.";
		const string CallbackUrlTooltip = "URL to redirect the user to after registration/authentication/password reset. " +
		                                  "Must be identical to Callback URL specified in Publisher Account in Login settings. Required if there are several Callback URLs.";
		const string SteamAuthTooltip = "If enabled, Login try find Steam client and get `session_ticket`." +
										"Then this ticket will be changed to JWT.";
		const string PlatformTooltip = "Publishing platform the user plays on.";
		
		[MenuItem("Window/Xsolla/Edit Settings", false, 1000)]
		public static void Edit()
		{
			Selection.activeObject = XsollaSettings.Instance;
		}

		public override void OnInspectorGUI()
		{
			using (new EditorGUILayout.VerticalScope("box"))
			{
				GUILayout.Label("Login SDK Settings", EditorStyles.boldLabel);
				
				XsollaSettings.LoginId = EditorGUILayout.TextField(new GUIContent("Login ID [?]", LoginIdTooltip),  XsollaSettings.LoginId);
				XsollaSettings.UseSteamAuth = EditorGUILayout.Toggle(new GUIContent("Use Steam authorization?", SteamAuthTooltip), XsollaSettings.UseSteamAuth);
				XsollaSettings.UseProxy = EditorGUILayout.Toggle("Enable proxy?", XsollaSettings.UseProxy);
				XsollaSettings.CallbackUrl = EditorGUILayout.TextField(new GUIContent("Callback URL [?]", CallbackUrlTooltip),  XsollaSettings.CallbackUrl);
				XsollaSettings.IsShadow = EditorGUILayout.Toggle("Shadow build?", XsollaSettings.IsShadow);
			}
      
			EditorGUILayout.Space();
			
			using (new EditorGUILayout.VerticalScope("box"))
			{
				GUILayout.Label("Store SDK Settings", EditorStyles.boldLabel);
				
				XsollaSettings.StoreProjectId = EditorGUILayout.TextField(new GUIContent("Project ID"),  XsollaSettings.StoreProjectId);
				XsollaSettings.IsSandbox = EditorGUILayout.Toggle("Enable sandbox?", XsollaSettings.IsSandbox);
				XsollaSettings.Platform = (PlatformType)EditorGUILayout.EnumPopup(new GUIContent("Publishing platform", PlatformTooltip), XsollaSettings.Platform);
			}

			EditorGUILayout.Space();
			
			using (new EditorGUILayout.VerticalScope("box"))
			{
				GUILayout.Label("PayStation SDK Settings", EditorStyles.boldLabel);

				XsollaSettings.PaystationTheme = (PaystationTheme)EditorGUILayout.EnumPopup("Paystation theme", XsollaSettings.PaystationTheme);
				XsollaSettings.PayStationTokenRequestUrl = EditorGUILayout.TextField(new GUIContent("Token request URL"),  XsollaSettings.PayStationTokenRequestUrl);
				XsollaSettings.InAppBrowserEnabled = EditorGUILayout.Toggle("Enable in-app browser?", XsollaSettings.InAppBrowserEnabled);
			}
      
			EditorGUILayout.Space();
		}
	}
}

