$('.password-cell').each(function () {
    // Get the actual password
    password = $(this).text().trim();
    console.log(password);
    console.log(password.length);

    // Replace the text with bullet points
    var maskedPassword = '•'.repeat(password.length);
    console.log(maskedPassword);


    // Set the cell's content to the masked password
    $(this).text(maskedPassword);
});