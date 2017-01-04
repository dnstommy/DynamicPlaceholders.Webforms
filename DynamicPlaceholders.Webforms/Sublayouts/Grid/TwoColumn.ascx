<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoColumn.ascx.cs" Inherits="DynamicPlaceholders.Webforms.Sublayouts.Grid.TwoColumn" %>
<%@ Register TagPrefix="fdp" Namespace="DynamicPlaceholders.Webforms.Control" Assembly="DynamicPlaceholders.Webforms" %>

<div class="row">
    <div class="col-md-6">
        <fdp:PlaceholderControl runat="server" ID="col1" Key="col1" />
    </div>
    <div class="col-md-6">
        <fdp:PlaceholderControl runat="server" ID="col2" Key="col2" />
    </div>
</div>

