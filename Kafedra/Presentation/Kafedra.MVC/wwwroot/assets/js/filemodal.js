const dropArea = document.getElementById('dropArea');
const fileInput = document.getElementById('fileInput');
const previewImage = document.getElementById('previewImage');
let upload = document.querySelector(".upload-area-icon");
let desc = document.querySelector(".upload-area-description");
dropArea.addEventListener("click", function () {
    this.nextElementSibling.click();
})
dropArea.addEventListener('dragover', (e) => {
    e.preventDefault();
    dropArea.classList.add('active');
});

dropArea.addEventListener('dragleave', () => {
    dropArea.classList.remove('active');
});

dropArea.addEventListener('drop', (e) => {
    e.preventDefault();
    dropArea.classList.remove('active');

    const file = e.dataTransfer.files[0];
    if (file && file.type.startsWith('image/')) {
        const reader = new FileReader();

        reader.onload = (event) => {
          //  previewImage.src = event.target.result;
           // previewImage.style.display = 'block';
            desc.innerText = file.name;
            desc.style.color = "#006A4E";
        };

        reader.readAsDataURL(file);
    }
});

fileInput.addEventListener('change', () => {
    const file = fileInput.files[0];
    if (file && file.type.startsWith('image/')) {
        const reader = new FileReader();

        reader.onload = (event) => {
          //  previewImage.src = event.target.result;
         //   previewImage.style.display = 'block';
            desc.innerText = file.name;
            desc.style.color = "#006A4E";
        };

        reader.readAsDataURL(file);
    }
});
