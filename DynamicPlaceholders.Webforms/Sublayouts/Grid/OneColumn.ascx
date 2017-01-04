<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneColumn.ascx.cs" Inherits="DynamicPlaceholders.Webforms.Sublayouts.Grid.OneColumn" %>
<%@ Register TagPrefix="fdp" Namespace="DynamicPlaceholders.Webforms.Control" Assembly="DynamicPlaceholders.Webforms" %>

<div class="row">
    <div class="col-md-12">
        <fdp:PlaceholderControl runat="server" ID="col1" Key="col1" />
    </div>
</div>
