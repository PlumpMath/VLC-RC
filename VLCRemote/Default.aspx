<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VLCRemote._Default" %>

<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>TV Remote</title>
	<meta name="viewport" content="width=320, initial-scale=1">
	<style>
		.square {width: 50px; height: 50px; display:inline-block;}
	</style> 
</head>
<body style="width: 320">
	<form id="form1" runat="server" width="320" style="display: block; width: 320px">
		<asp:Button ID="LoadDvdBtn" runat="server" OnClick="LoadDvd" Text="Load DVD" Width="150" Style="float: left" />
		<asp:Button ID="LoadFileBtn" runat="server" OnClick="LoadFile" Text="Load file" Width="150" Style="float: right;" />
		<div style="clear: both; height: 10px">
			&nbsp;</div>
		<asp:Button ID="PlayPauseBtn" runat="server" OnClick="PlayPause" Text="Play/Pause" Width="320" Height="60" />
		<div style="clear: both; height: 10px">
			&nbsp;</div>
		<asp:Button ID="MenuBtn" runat="server" OnClick="GoToMenu" Text="DVD Menu" Width="100" Style="float: left" />
		<asp:Button ID="ChapFwdBtn" runat="server" OnClick="ChapterNext" Text="Ch >" Width="50" Style="float: right;" />
		<asp:Button ID="ChapBackBtn" runat="server" OnClick="ChapterBack" Text="Ch <" Width="50" Style="float: right;" />
		<div style="clear: both; height: 10px">
			&nbsp;</div>
		<span class="square"></span>
		<asp:Button ID="NavUpBtn" runat="server" OnClick="NavUp" Text="/\" class="square" />
		<br />
		<asp:Button ID="NavActivateBtn" runat="server" OnClick="NavActivate" Text="Select" Style="float: right; width: 150px; height: 50px" />
		<asp:Button ID="NavLeftBtn" runat="server" OnClick="NavLeft" Text="<" class="square" /><span class="square"></span>
		<asp:Button ID="NavRightBtn" runat="server" OnClick="NavRight" Text=">" class="square" />
		<br />
		<span class="square"></span>
		<asp:Button ID="NavDnBtn" runat="server" OnClick="NavDown" Text="\/" class="square" />
	</form>
</body>
</html>
