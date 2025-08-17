<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class AppointmentDtoRequest extends FormRequest
{
    public function authorize()
    {
        return true;
    }

    public function rules()
    {
        return [
            'patient_id' => 'required|integer',
            'doctor_id' => 'required|integer',
            'scheduled_at' => 'required|date',
            'status' => 'required|string',
            'notes' => 'nullable|string',
        ];
    }
}
