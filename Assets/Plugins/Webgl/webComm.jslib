mergeInto(LibraryManager.library, {

  sendMsgToPage : function(text)
  {
    var convertedText = Pointer_stringfy(text);
    receiveMessageFromUnity(convertedText); // html must have this function
  }
});
