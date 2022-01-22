const base_url = location.origin;
console.log(`Base url: ${base_url}`)

async function load_notes() {
	const resp = await fetch(`${base_url}/api/notes`)

	const resp_json = await resp.json()

	const note_list_elem = document.querySelector("#notes-list")
	note_list_elem.children = []
	for (var note_index in resp_json) {
		const note = JSON.parse(resp_json[note_index])
		//console.log(note)
		const li_elem = document.createElement('li')
		li_elem.textContent = note.Note
		note_list_elem.appendChild(li_elem)
	}
}

load_notes()