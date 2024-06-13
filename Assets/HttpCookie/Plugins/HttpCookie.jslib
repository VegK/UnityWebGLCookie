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
	var name = UTF8ToString(nameArg);
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
	var name = UTF8ToString(nameArg);
	var value = UTF8ToString(valueArg);
	var expires = UTF8ToString(expiresArg);
	var path = UTF8ToString(pathArg);
	var domain = UTF8ToString(domainArg);
	var secure = UTF8ToString(secureArg);
	document.cookie = name + "=" + escape(value) +
		((expires) ? "; expires=" + expires : "") +
		((path) ? "; path=" + path : "") +
		((domain) ? "; domain=" + domain : "") +
		((secure) ? "; secure" : "");
}

};

mergeInto(LibraryManager.library, LibraryHttpCookie);