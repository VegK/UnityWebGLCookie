var LibraryHttpCookie = {

getHttpCookies: function()
{
	var cookies = document.cookie;
	var length = lengthBytesUTF8(cookies) + 1;
	var buffer = _malloc(length);
	stringToUTF8(cookies, buffer, length);
	return buffer;
},

getHttpCookie: function(nameArg)
{
	var name = Pointer_stringify(nameArg);
	var cookie = document.cookie;
	var search = name + "=";
	var setStr = "";
	var offset = 0;
	var end = 0;
	if (cookie.length > 0)
	{
		offset = cookie.indexOf(search);
		if (offset != -1)
		{
			offset += search.length;
			end = cookie.indexOf(";", offset);
			if (end == -1)
			{
				end = cookie.length;
			}
			setStr = unescape(cookie.substring(offset, end));
		}
	}

	var length = lengthBytesUTF8(setStr) + 1;
	var buffer = _malloc(length);
	stringToUTF8(setStr, buffer, length);
	return buffer;
},

setHttpCookie: function(nameArg, valueArg, expiresArg, pathArg, domainArg, secureArg)
{
	var name = Pointer_stringify(nameArg);
	var value = Pointer_stringify(valueArg);
	var expires = Pointer_stringify(expiresArg);
	var path = Pointer_stringify(pathArg);
	var domain = Pointer_stringify(domainArg);
	var secure = Pointer_stringify(secureArg);
	document.cookie = name + "=" + escape(value) +
		((expires) ? "; expires=" + expires : "") +
		((path) ? "; path=" + path : "") +
		((domain) ? "; domain=" + domain : "") +
		((secure) ? "; secure" : "");
}

};

mergeInto(LibraryManager.library, LibraryHttpCookie);